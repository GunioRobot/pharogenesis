replaceHtmlCharRefs

        | pos ampIndex scIndex special specialValue outString outPos newOutPos |

        outString _ String new: self size.
        outPos _ 0.

        pos _ 1.
        
        [ pos <= self size ] whileTrue: [ 
                "read up to the next ampersand"
                ampIndex _ self indexOf: $& startingAt: pos ifAbsent: [0].
                
                ampIndex = 0 ifTrue: [
                        pos = 1 ifTrue: [ ^self ] ifFalse: [ ampIndex _ self size+1 ] ].

                newOutPos _ outPos + ampIndex - pos.
                outString
                        replaceFrom: outPos + 1
                        to: newOutPos
                        with: self
                        startingAt: pos.
                outPos _ newOutPos.
                pos _ ampIndex.

                ampIndex <= self size ifTrue: [
                        "find the $;"
                        scIndex _ self indexOf: $; startingAt: ampIndex ifAbsent: [ self size + 1 ].

                        special _ self copyFrom: ampIndex+1 to: scIndex-1.       
                        specialValue _ String valueOfHtmlEntity: special. 

                        specialValue
                                ifNil: [
                                        "not a recognized entity.  wite it back"
								  scIndex > self size ifTrue: [ scIndex _ self size ].

                                        newOutPos _ outPos + scIndex - ampIndex + 1.
                                        outString
                                                replaceFrom: outPos+1
                                                to: newOutPos
                                                with: self
                                                startingAt: ampIndex.
                                        outPos _ newOutPos.]
                                ifNotNil: [
                                        outPos _ outPos + 1.
                                        outString at: outPos put: specialValue.].
                        
                        pos _ scIndex + 1. ]. ].


        ^outString copyFrom: 1 to: outPos