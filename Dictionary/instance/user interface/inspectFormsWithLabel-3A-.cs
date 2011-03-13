inspectFormsWithLabel: aLabel
        "Open a Form Dictionary inspector on the receiver, with the given label."

        | viewClass aList aGraphicalMenu |
        
        self couldOpenInMorphic
                ifTrue:
                        [aList _ self collect: [:f | f].
                        aList isEmpty ifTrue: [^ self inform: 'Empty!'].
                        aGraphicalMenu _ GraphicalDictionaryMenu new 
                                initializeFor: nil
                                fromDictionary: self.
                        ^ HandMorph attach: (aGraphicalMenu wrappedInWindowWithTitle: aLabel)].

        viewClass _ PluggableTextView.
        Smalltalk at: #FormInspectView
                ifPresent: [:formInspectView | viewClass _ formInspectView].
        ^ DictionaryInspector
                openOn: self
                withEvalPane: true
                withLabel: aLabel
                valueViewClass: viewClass