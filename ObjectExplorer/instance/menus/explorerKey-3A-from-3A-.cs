explorerKey: aChar from: view

	"Similar to #genericMenu:..."
	| insideObject parentObject |
	currentSelection ifNotNil: [
		insideObject _ self object.
		parentObject _ self parentObject.
		inspector ifNil: [inspector _ Inspector new].
		inspector
			inspect: parentObject;
			object: insideObject.

		aChar == $i ifTrue: [^ self inspectSelection].
		aChar == $I ifTrue: [^ self exploreSelection].

		aChar == $b ifTrue:	[^ inspector browseMethodFull].
		aChar == $h ifTrue:	[^ inspector classHierarchy].
		aChar == $c ifTrue: [^ inspector copyName].
		aChar == $p ifTrue: [^ inspector browseFullProtocol].
		aChar == $N ifTrue: [^ inspector browseClassRefs].
		aChar == $t ifTrue: [^ inspector tearOffTile].
		aChar == $v ifTrue: [^ inspector viewerForValue]].

	^ self arrowKey: aChar from: view