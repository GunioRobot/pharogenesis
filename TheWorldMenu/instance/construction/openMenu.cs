openMenu

        "Build the open window menu for the world."
        | menu |
        menu _ self menu: 'open...'.
        self fillIn: menu from: {

                {'browser' . { Browser . #openBrowser} }.
                {'package browser' . { PackagePaneBrowser . #openBrowser} }.
                {'method finder' . { self . #openSelectorBrowser} }.
                {'workspace' . {self . #openWorkspace} }.
                {'file list' . {self . #openFileList} }.
                {'file...' . { FileList . #openFileDirectly} }.
                {'transcript' . {self . #openTranscript} }.
                {'inner world' . { WorldWindow . #test1} }.
                nil.
                {'simple change sorter' . {self . #openChangeSorter1} }.
                {'dual change sorter' . {self . #openChangeSorter2} }.
                nil.
                {'email reader' . {self . #openEmail} }.
                {'web browser' . { Scamper . #openAsMorph} }.
                {'IRC chat' . {self . #openIRC} }.
                nil.
        }.
        self mvcProjectsAllowed ifTrue: [
                self fillIn: menu from: { {'mvc project' . {self. #openMVCProject} } }
        ].
        ^self fillIn: menu from: { 
                {'morphic project' . {self. #openMorphicProject} }.
        }.

