renameScript
	"Invoked at user menu request"
	| reply aPosition oldSelector dflt oldStatus oldOwner aUserScript |
	oldSelector _ self scriptName.
	self flag: #deferred.
	aUserScript _ playerScripted class userScriptForPlayer: self selector: oldSelector.
	aUserScript isTextuallyCoded ifTrue:
		[self inform: 'Sorry, for now you can only rename tiled scripts'.
		^ self].

	oldStatus _ self scriptInstantiation status.
	dflt _ self isAnonymous ifTrue: [''] ifFalse: [self scriptTitle].
	reply _   FillInTheBlank request: 'Script Name' initialAnswer: dflt.
 	reply size == 0 ifTrue: [^ self].
	reply first isUppercase ifTrue: [^ self inform: 'Illegal script name'].
	((reply _ reply asSymbol) == scriptName) ifTrue: [^ self].
	(Scanner isLiteralSymbol: reply) ifFalse: [^ self inform: 'Bad script name, please try again'].
	self titleMorph borderColor: Color black.
	scriptName _ reply.
	playerScripted class atSelector: reply putScriptEditor: self.
	self scriptInstantiation status: oldStatus.
	playerScripted class removeScriptNamed: oldSelector.
	playerScripted actorState instantiatedUserScriptsDictionary removeKey: oldSelector.
	submorphs first delete.  "the button row"
	self addMorphFront: self buttonRowForEditor.  "up to date"
	self install.
	aPosition _ self position.
	oldOwner _ self topRendererOrSelf owner.
	self delete
	playerScripted costume viewAfreshIn: oldOwner showingScript: scriptName at: aPosition