validateTheProjectName

	| proposed |

	proposed _ (namedFields at: 'projectname') contents string.
	proposed size = 0 ifTrue: [
		self inform: 'I do need a name for the project'.
		^false
	].
	proposed size > 24 ifTrue: [
		self inform: 'Please make the name 24 characters or less'.
		^false
	].
	(Project isBadNameForStoring: proposed) ifTrue: [
		self inform: 'Please remove any funny characters from the name'.
		^false
	].
	proposed = theProject name ifTrue: [^true].
	(ChangeSorter changeSetNamed: proposed) ifNotNil: [
		Utilities inform: 'Sorry that name is already used'.
		^false
	].
	^true