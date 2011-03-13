changeSetListKey: aChar from: view
	"Respond to a Command key.  I am a model with a listView that has a list of changeSets."

	aChar == $b ifTrue: [^ self browseChangeSet].
	aChar == $f ifTrue: [^ self findCngSet].
	aChar == $m ifTrue: [^ self newCurrent].
	aChar == $n ifTrue: [^ self newSet].
	aChar == $o ifTrue: [^ self fileOut].
	aChar == $r ifTrue: [^ self rename].
	aChar == $x ifTrue: [^ self remove].
	aChar == $p ifTrue: [^ self addPreamble].
	aChar == $c ifTrue: [^ self copyAllToOther].
	aChar == $D ifTrue: [^ self toggleDiffing]. 

	^ self messageListKey: aChar from: view