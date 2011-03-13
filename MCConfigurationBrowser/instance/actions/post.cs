post
	"Take the current configuration and post an update"
	| name update managers names choice |
	(self checkRepositories and: [self checkDependencies]) ifFalse: [^self].
	name := FillInTheBlank
		request: 'Update name (.cs) will be appended):'
		initialAnswer: (self configuration name ifNil: ['']).
	name isEmpty ifTrue:[^self].
	self configuration name: name.
	update := MCPseudoFileStream on: (String new: 100).
	update localName: name, '.cs'.
	update nextPutAll: '"Change Set:		', name.
	update cr; nextPutAll: 'Date:			', Date today printString.
	update cr; nextPutAll: 'Author:			Posted by Monticello'.
	update cr; cr; nextPutAll: 'This is a configuration map created by Monticello."'.

	update cr; cr; nextPutAll: '(MCConfiguration fromArray: #'.
	self configuration fileOutOn: update.
	update nextPutAll: ') upgrade.'.
	update position: 0.

	managers := Smalltalk at: #UpdateManager ifPresent:[:mgr| mgr allRegisteredManagers].
	managers ifNil:[managers := #()].
	managers size > 0 ifTrue:[
		| servers index |
		servers := ServerDirectory groupNames asSortedArray.
		names := (managers collect:[:each| each packageVersion]), servers.
		index := UIManager default chooseFrom: names lines: {managers size}.
		index = 0 ifTrue:[^self].
		index <= managers size ifTrue:[
			| mgr |
			mgr := managers at: index.
			^mgr publishUpdate: update.
		].
		choice := names at: index.
	] ifFalse:[
		names := ServerDirectory groupNames asSortedArray.
		choice := (SelectionMenu labelList: names selections: names) startUp.
		choice == nil ifTrue: [^ self].
	].
	(ServerDirectory serverInGroupNamed: choice) putUpdate: update.