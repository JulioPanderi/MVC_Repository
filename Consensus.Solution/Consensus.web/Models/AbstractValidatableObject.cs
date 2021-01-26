﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Consensus.WEB.Models
{
    public class AbstractValidatableObject : IValidatableObject
    {
        public virtual IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            var task = ValidateAsync(validationContext, source.Token);
            Task.WaitAll(task);
            return task.Result;
        }

        public virtual Task<IEnumerable<ValidationResult>> ValidateAsync(ValidationContext validationContext, CancellationToken cancellationToken)
        {
            return Task.FromResult((IEnumerable<ValidationResult>) new List<ValidationResult>());
        }
    }
}
