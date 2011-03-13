parse: textOrStream in: aClass notifying: req dialect: useDialect
        "Compile the argument, textOrStream, with respect to the class, aClass, 
        and answer the MethodNode that is the root of the resulting parse tree. 
        Notify the argument, req, if an error occurs. The failBlock is defaulted to 
        an empty block."

        self from: textOrStream class: aClass context: nil notifying: req.
        ^ ((useDialect and: [RequestAlternateSyntaxSetting signal])
                ifTrue: [DialectParser]
                ifFalse: [Parser]) new
                        parse: sourceStream
                        class: class
                        noPattern: false
                        context: context
                        notifying: requestor
                        ifFail: []