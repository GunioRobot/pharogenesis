windowsMenu
        "Build the windows menu for the world."

        ^ self fillIn: (self menu: 'windows & flaps...') from: {  
                { 'find window' . { #myWorld . #findWindow: }. 'Presents a list of all windows; if you choose one from the list, it becomes the active window.'}.

                { 'find changed browsers...' . { #myWorld . #findDirtyBrowsers: }. 'Presents a list of browsers that have unsubmitted changes; if you choose one from the list, it becomes the active window.'}.

                { 'find changed windows...' . { #myWorld . #findDirtyWindows: }. 'Presents a list of all windows that have unsubmitted changes; if you choose one from the list, it becomes the active window.'}.
			nil.

                { 'find a transcript (t)' . { #myWorld . #findATranscript: }. 'Brings an open Transcript to the front, creating one if necessary, and makes it the active window'}.

               { 'find a change sorter (C)' . { #myWorld . #findAChangeSorter: }. 'Brings an open change sorter to the front, creating one if necessary, and makes it the active window'}.
			 nil.

                { #staggerPolicyString . { self . #toggleWindowPolicy }. 'stagger: new windows positioned so you can see a portion of each one.
                tile: new windows positioned so that they do not overlap others, if possible.'}.

                nil.
                { 'collapse all windows' . { #myWorld . #collapseAll }. 'Reduce all open windows to collapsed forms that only show titles.'}.
                { 'expand all windows' . { #myWorld . #expandAll }. 'Expand all collapsed windows back to their expanded forms.'}.
                { 'close top window (w)' . { SystemWindow . #closeTopWindow }. 'Close the topmost window if possible.'}.
                { 'send top window to back (\)' . { SystemWindow . #sendTopWindowToBack  }. 'Make the topmost window become the backmost one, and activate the window just beneath it.'}.
			 { 'move windows onscreen' . { #myWorld . #bringWindowsFullOnscreen }. 'Make all windows fully visible on the screen'}.

                nil.
                { 'delete unchanged windows' . { #myWorld . #closeUnchangedWindows }. 'Deletes all windows that do not have unsaved text edits.'}.
                { 'delete non-windows' . { #myWorld . #deleteNonWindows }. 'Deletes all non-window morphs lying on the world.'}.
                { 'delete both of the above' . { self . #cleanUpWorld }. 'deletes all unchanged windows and also all non-window morphs lying on the world, other than flaps.'}.

                nil.
            "    { #suppressFlapsString . { self . #toggleFlapSuppressionInProject }. 'Governs whether flaps should be shown in this project'}."
                { #useGlobalFlapsString . { self. #toggleWhetherToUseGlobalFlaps }. 'Governs whether a universal set of "global" flaps should be sharable by all morphic projects.'}.
			{ #whichGlobalFlapsString . { Utilities. #offerGlobalFlapsMenu }. 'Put up a menu that allows you to choose which global flaps to show in this project'. #globalFlapsEnabled}.

                { #newGlobalFlapString  . { Utilities . #addGlobalFlap }. 'Create a new flap that will be shared by all morphic projects'.  #globalFlapsEnabled}.
                nil.

                { 'new project flap...'  . { Utilities . #addLocalFlap }. 'Create a new flap to be used only in this project.'}.
                { 'add stack-tools flap'  . { Utilities . #addStackToolsFlap }. 'Add a flap in this project that offers tools for creating stacks and cards.'}.
				nil.

                { 'about flaps...' . { Utilities . #explainFlaps }. 'Gives a window full of details about how to use flaps.'}.

        }