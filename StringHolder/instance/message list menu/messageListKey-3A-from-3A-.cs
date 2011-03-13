messageListKey: aChar from: view
	"Respond to a Command key.  I am a model with a code pane, and I also
	have a listView that has a list of methods.  The view knows how to get
	the list and selection."

	| sel class |
	aChar == $D ifTrue: [^ self toggleDiffing].
	(class _ self selectedClassOrMetaClass) ifNil: [^ self arrowKey: aChar from: view].
	sel _ self selectedMessageName.
	aChar == $b ifTrue: [^ Browser fullOnClass: class selector: sel].
	aChar == $N ifTrue: [^ self browseClassRefs].
	aChar == $i ifTrue: [^ self methodHierarchy].
	aChar == $h ifTrue: [^ self classHierarchy].
	aChar == $p ifTrue: [^ self browseFullProtocol].


	sel ifNotNil: 
		[aChar == $m ifTrue: [^ Smalltalk browseAllImplementorsOf: sel].
		aChar == $n ifTrue: [^ Smalltalk browseAllCallsOn: sel].
		aChar == $v ifTrue: [^ self browseVersions].
		aChar == $O ifTrue: [^ self openSingleMessageBrowser].
		aChar == $x ifTrue: [^ self removeMessage]].

	^ self arrowKey: aChar from: view