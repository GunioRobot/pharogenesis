debugMenu

        | menu |

        menu _ self menu: 'debug...'.
        ^self fillIn: menu from: { 
                { 'inspect world' . { #myWorld . #inspect } }.
                { 'explore world' . { #myWorld . #explore } }.
                { 'inspect model' . { self . #inspectWorldModel } }.
                        " { 'talk to world...' . { self . #typeInMessageToWorld } }."
                { 'start MessageTally' . { self . #startMessageTally } }.
                { 'start/browse MessageTally' . { self . #startThenBrowseMessageTally } }.
                { 'open process browser' . { ProcessBrowser . #open } }.
                nil.
                        "(self hasProperty: #errorOnDraw) ifTrue:  Later make this come up only when needed."
                { 'start drawing again' . { #myWorld . #resumeAfterDrawError } }.
                { 'start stepping again' . { #myWorld . #resumeAfterStepError } }.
                nil.
                { 'call #tempCommand' . { #myWorld . #tempCommand } }.
                { 'define #tempCommand' . { #myWorld . #defineTempCommand } }.
        }
