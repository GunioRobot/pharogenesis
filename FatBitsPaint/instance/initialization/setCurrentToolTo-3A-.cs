setCurrentToolTo: aDictionary

        currentTools _ aDictionary.
        currentSelectionMorph ifNotNil: [currentSelectionMorph delete. currentSelectionMorph _ nil]