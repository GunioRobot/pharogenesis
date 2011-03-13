selectorsChanged
	"Return a list of methods in the current change set (or satisfying some 
	other such criterion) that are in the protocol of this object"
	| aList aClass targetedClass |
	targetedClass := self targetObject
				ifNil: [targetClass]
				ifNotNil: [self targetObject class].
	aList := OrderedCollection new.
	ChangeSet current methodChanges
		associationsDo: [:classChgAssoc | classChgAssoc value
				associationsDo: [:methodChgAssoc | (methodChgAssoc value == #change
							or: [methodChgAssoc value == #add])
						ifTrue: [(aClass := targetedClass whichClassIncludesSelector: methodChgAssoc key)
								ifNotNil: [aClass name = classChgAssoc key
										ifTrue: [aList add: methodChgAssoc key]]]]].
	^ aList