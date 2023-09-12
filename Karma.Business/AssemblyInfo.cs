using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Aspects.Postsharp.LogAspects;
using Karma.Core.Aspects.Postsharp.ExceptionsAspects;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "Karma.Business.Concrete.*")]
[assembly: ExceptionsLogAspect(typeof(FileLogger), AttributeTargetTypes = "Karma.Business.Concrete.*")]