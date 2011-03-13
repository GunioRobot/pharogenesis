removeChangeSetsBefore: stopName
	"Remove all change sets before the one with the given name."
	"ChangeSorter removeChangeSetsBefore: 'Beyond'" 

	| stop |
	(self confirm:
'Really remove all change sets before
"', stopName, '"?')
		ifFalse: [^ self].

	self gatherChangeSets.
	stop _ false.
	ChangeSet allInstancesDo: [:changeSet |
		changeSet name = stopName ifTrue: [stop _ true].
		stop ifFalse: [
			changeSet okayToRemove ifTrue: [
				AllChangeSets remove: changeSet ifAbsent: [].
				changeSet wither]]].
	Smalltalk garbageCollect.
	AllChangeSets _ OrderedCollection new.
	self gatherChangeSets.
