using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Shawpnojatra_Foundation.Models
{
	public class EnumClasses
	{
		public enum MessageAgenda
		{[Description("জরুরি খাদ্য সহয়তা")]
			জরুরিখাদ্যসহয়তা,
			[Description("ফ্রি বইয়ের আবেদন")]
			ফ্রিবইয়েরাবেদন,
			[Description("জরুরি চিকিৎসা খরচের আবেদন")]
			জরুরিচিকিৎসাকরচেরাবেদন,
			[Description("সমস্যা নিরসনের আবেদন")]
			সমস্যানিরসনেরাবেদন,

		}
	}
}
