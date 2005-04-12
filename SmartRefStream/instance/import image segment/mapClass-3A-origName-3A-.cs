mapClass: newClass origName: originalName
	"See if instances changed shape.  If so, make a fake class for the old shape and return it.  Remember the original class name."

	| newName oldInstVars fakeClass |
	newClass isMeta ifTrue: [^ newClass].
	newName _ newClass name.
	(steady includes: newClass) & (newName == originalName) ifTrue: [^ newClass].
		"instances in the segment have the right shape"
	oldInstVars _ structures at: originalName ifAbsent: [
			self error: 'class is not in structures list'].	"Missing in object file"

	"Allow mapping from old to new string names"
	(newName == #ByteString and:[originalName == #String]) ifTrue:[^newClass].
	(newName == #WideString and:[originalName == #MultiString]) ifTrue:[^newClass].
	(newName == #WideSymbol and:[originalName == #MultiSymbol]) ifTrue:[^newClass].

	fakeClass _ Object subclass: ('Fake37', originalName) asSymbol
		instanceVariableNames: oldInstVars allButFirst
		classVariableNames: ''
		poolDictionaries: ''
		category: 'Obsolete'.
	ChangeSet current removeClassChanges: fakeClass name.	"reduce clutter"
	^ fakeClass
