reconstructTextWindowsFromFileNamed: aName
	"Utilities reconstructTextWindowsFromFileNamed: 'TextWindows'"
	| aReferenceStream aDict |
	aReferenceStream _ ReferenceStream fileNamed: aName.
	aDict _ aReferenceStream next.
	aReferenceStream close.
	aDict associationsDo:
		[:assoc |
			(StringHolder new contents: assoc value) openLabel: assoc key andTerminate: false].
	Smalltalk isMorphic ifFalse:
		[ScheduledControllers restore.
		Processor terminateActive]