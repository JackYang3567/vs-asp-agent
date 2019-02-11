using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace Game.Facade
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), System.Diagnostics.DebuggerNonUserCode, System.Runtime.CompilerServices.CompilerGenerated]
	internal class ResMessage
	{
		private static System.Resources.ResourceManager resourceMan;
		private static System.Globalization.CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static System.Resources.ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(ResMessage.resourceMan, null))
				{
					System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("Game.Facade.ResMessage", typeof(ResMessage).Assembly);
					ResMessage.resourceMan = resourceManager;
				}
				return ResMessage.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static System.Globalization.CultureInfo Culture
		{
			get
			{
				return ResMessage.resourceCulture;
			}
			set
			{
				ResMessage.resourceCulture = value;
			}
		}
		internal static string EmptyAccounts
		{
			get
			{
				return ResMessage.ResourceManager.GetString("EmptyAccounts", ResMessage.resourceCulture);
			}
		}
		internal static string EmptyPassword
		{
			get
			{
				return ResMessage.ResourceManager.GetString("EmptyPassword", ResMessage.resourceCulture);
			}
		}
		internal static string Error_DeleteSuperAdministrator
		{
			get
			{
				return ResMessage.ResourceManager.GetString("Error_DeleteSuperAdministrator", ResMessage.resourceCulture);
			}
		}
		internal static string Error_ExistsLinkEmail
		{
			get
			{
				return ResMessage.ResourceManager.GetString("Error_ExistsLinkEmail", ResMessage.resourceCulture);
			}
		}
		internal static string Error_ExistsUser
		{
			get
			{
				return ResMessage.ResourceManager.GetString("Error_ExistsUser", ResMessage.resourceCulture);
			}
		}
		internal static string Hit_SuperAdministrator
		{
			get
			{
				return ResMessage.ResourceManager.GetString("Hit_SuperAdministrator", ResMessage.resourceCulture);
			}
		}
		internal ResMessage()
		{
		}
	}
}
