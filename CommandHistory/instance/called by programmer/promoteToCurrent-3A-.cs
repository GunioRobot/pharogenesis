promoteToCurrent: aCommand
	"Very unusual and speculative and unfinished!.  Not currently reachable.  For the real thing, we presumably march forward or backward from the current command pointer to the target command in an orderly fashion, doing or undoing each command in turn."

	| itsIndex |
	Preferences useUndo ifFalse: [^ self].
	itsIndex _ history indexOf: aCommand ifAbsent: [nil].
	itsIndex ifNotNil:
		[history remove: aCommand ifAbsent: []].
	history add: (lastCommand _ aCommand).
	itsIndex < history size ifTrue:
		[excursions add: (history copyFrom: (itsIndex to: history size))].
	history _ (history copyFrom: 1 to: itsIndex) copyWith: aCommand.

	lastCommand _ aCommand.
	aCommand doCommand.
	lastCommand phase: #done.