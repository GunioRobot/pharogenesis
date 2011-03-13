helpMenu
        "Build the help menu for the world."
        | screenCtrl |

        screenCtrl _ ScreenController new.
        ^self fillIn: (self menu: 'help...') from:
        {
                {'about this system...'. {Smalltalk. #aboutThisSystem}. 'current version information.'}.
                {'update code from server'. {Utilities. #updateFromServer}. 'load latest code updates via the internet'}.
                {'preferences...'. {Preferences. #openPreferencesInspector}. 'view and change various options.'}.
                nil.
                {'command-key help'. { Utilities . #openCommandKeyHelp}. 'summary of keyboard shortcuts.'}.
                {'world menu help'. { self . #worldMenuHelp}. 'helps find menu items buried in submenus.'}.
                        "{'info about flaps' . { Utilities . #explainFlaps}. 'describes how to enable and use flaps.'}."
                {'font size summary' . { Utilities . #fontSizeSummary}.  'summary of names and sizes of available fonts.'}.
                {'useful expressions' . { Utilities . #openStandardWorkspace}. 'a window full of useful expressions.'}.
                {'graphical imports' . { Smalltalk . #viewImageImports}.  'view the global repository called ImageImports; you can easily import external graphics into ImageImports via the FileList'}.
                {'standard graphics library' . { ScriptingSystem . #inspectFormDictionary}.  'lets you view and change the system''s standard library of graphics.'}.
                nil.
                {'telemorphic...' . {self. #remoteDo}.  'commands for doing multi-machine "telemorphic" experiments'}.
                {#soundEnablingString . { Preferences . #toggleSoundEnabling}. 'turning sound off will completely disable Squeak''s use of sound.'}.
                {'definition for...' . { Utilities . #lookUpDefinition}.  'if connected to the internet, use this to look up the definition of an English word.'}.
                nil.

                {'set author initials...' . { screenCtrl . #setAuthorInitials }. 'supply initials to be used to identify the author of code and other content.'}.
                {'vm statistics' . { screenCtrl . #vmStatistics}.  'obtain some intriguing data about the vm.'}.
                {'space left' . { screenCtrl . #garbageCollect}. 'perform a full garbage-collection and report how many bytes of space remain in the image.'}.
        }

