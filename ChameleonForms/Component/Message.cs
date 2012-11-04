﻿using System;
using System.Web;
using ChameleonForms.Enums;
using ChameleonForms.Templates;

namespace ChameleonForms.Component
{
    /// <summary>
    /// Wraps the output of a message to display to a user.
    /// </summary>
    /// <typeparam name="TModel">The view model type for the current view</typeparam>
    /// <typeparam name="TTemplate">The type of HTML template renderer the form is using</typeparam>
    public class Message<TModel, TTemplate> : FormComponent<TModel, TTemplate> where TTemplate : IFormTemplate
    {
        private readonly MessageType _messageType;
        private readonly string _heading;

        /// <summary>
        /// Creates a message.
        /// </summary>
        /// <param name="form">The form the message is being created in</param>
        /// <param name="messageType">The type of message to display</param>
        /// <param name="heading">The heading for the message</param>
        public Message(IForm<TModel, TTemplate> form, MessageType messageType, string heading) : base(form, false)
        {
            _messageType = messageType;
            _heading = heading;
            Initialise();
        }

        public override IHtmlString Begin()
        {
            return Form.Template.BeginMessage(_messageType, _heading);
        }

        public override IHtmlString End()
        {
            return Form.Template.EndMessage();
        }

        /// <summary>
        /// Creates the HTML for a paragraph in the message.
        /// </summary>
        /// <param name="paragraph">The paragraph to output</param>
        /// <returns>The HTML for the paragraph</returns>
        public virtual IHtmlString Paragraph(string paragraph)
        {
            return new HtmlString(string.Format("<p>{0}</p>{1}", HttpUtility.HtmlEncode(paragraph), Environment.NewLine));
        }
    }

    /// <summary>
    /// Extension methods for the creation of messages.
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        /// Creates a message.
        /// </summary>
        /// <typeparam name="TModel">The view model type for the current view</typeparam>
        /// <typeparam name="TTemplate">The type of HTML template renderer the form is using</typeparam>
        /// <param name="form">The form the message is being created in</param>
        /// <param name="messageType">The type of message to display</param>
        /// <param name="heading">The heading for the message</param>
        /// <returns>The message</returns>
        public static Message<TModel, TTemplate> BeginMessage<TModel, TTemplate>(this IForm<TModel, TTemplate> form, MessageType messageType, string heading) where TTemplate : IFormTemplate
        {
            return new Message<TModel, TTemplate>(form, messageType, heading);
        }
    }
}