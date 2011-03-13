openOn: anObject withEvalPane: withEval withLabel: label
        
        self couldOpenInMorphic ifTrue:
                [^ self openAsMorphOn: anObject withEvalPane: withEval
                        withLabel: label valueViewClass: nil].
        ^ self openOn: anObject 
                withEvalPane: withEval 
                withLabel: label 
                valueViewClass: PluggableTextView
