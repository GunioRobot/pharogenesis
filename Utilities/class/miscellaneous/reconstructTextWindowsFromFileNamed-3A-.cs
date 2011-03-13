reconstructTextWindowsFromFileNamed: aName
	"Utilities reconstructTextWindowsFromFileNamed: 'TextWindows'"
	| aReferenceStream aDict |
	aReferenceStream :=  ReferenceStream fileNamed: aName.
	aDict :=  aReferenceStream next.
	aReferenceStream close.
	aDict associationsDo:
		[:assoc |
			(StringHolder new contents: assoc value) openAsMorphLabel: assoc key ]