copyRecordingIn: aDict
	| new |
	new _ super copyRecordingIn: aDict.
	downArrow ifNotNil:
		[new downArrow: 
			((aDict includesKey: downArrow)
				ifTrue: [aDict at: downArrow]
				ifFalse: [downArrow copyRecordingIn: aDict])].

	upArrow ifNotNil:
		[new upArrow: 
			((aDict includesKey: upArrow)
				ifTrue: [aDict at: upArrow]
				ifFalse: [upArrow copyRecordingIn: aDict])].

	suffixArrow ifNotNil:
		[new suffixArrow: 
			((aDict includesKey: suffixArrow)
				ifTrue: [aDict at: suffixArrow]
				ifFalse: [suffixArrow copyRecordingIn: aDict])].
	"actualObject gets fixed by a different mechanism.  The commented-out code below caused big difficulties when a script was being copied for use in the same actor"
"	actualObject ifNotNil:
		[new actualObject: 
			((aDict includesKey: actualObject)
				ifTrue: [aDict at: actualObject]
				ifFalse: [actualObject copyRecordingIn: aDict])]."

	^ new
