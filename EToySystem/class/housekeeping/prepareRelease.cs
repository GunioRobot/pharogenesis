prepareRelease
	"To prepare a release of the EToy system, first make a copy of your image. Start that image and:
		1. close all windows and projects
		2. clean any garbage out of the following:
			Smalltalk at: #GIFImports.
			(Smalltalk keys select: [:k | ((Smalltalk at: k) isKindOf: Behavior) not])
				asSortedCollection asArray.
			SampledSound soundLibrary.
		3. run this method
		4. save the image"
	"EToySystem prepareRelease"

	HandMorph initialize.  "free cached ColorChart"
	PaintBoxMorph releaseTemporaryForms.
	PaintBoxMorph prototype stampHolder clear.  "clear stamps"
	PaintBoxMorph prototype delete.  "break link to world, if any"
	Smalltalk removeKey: #AA ifAbsent: [].
	Smalltalk removeKey: #BB ifAbsent: [].
	Smalltalk removeKey: #CC ifAbsent: [].
	Smalltalk removeKey: #DD ifAbsent: [].
	Smalltalk removeKey: #Temp ifAbsent: [].

 	Preferences setPreference: #quitWhenExitingImagineeringStudio toValue: true.
	Preferences setPreference: #showDevelopersEToys toValue: false.
	Preferences setPreference: #startImagineeringStudio toValue: true.
	Preferences setPreference: #updateFromServer toValue: false.
	Preferences setPreference: #warnIfNoChangesFile toValue: false.
	Preferences setPreference: #warnIfNoSourcesFile toValue: false.

	Smalltalk minorShrink.
	SystemOrganization removeSystemCategory: 'Morphic-Windows'.
	SystemOrganization removeSystemCategory: 'Graphics-Files'. "No license for GIF reader"
	ScriptingSystem reclaimSpace.
	Smalltalk cleanOutUndeclared.
	Smalltalk reclaimDependents.
	Smalltalk forgetDoIts.
	Smalltalk removeEmptyMessageCategories.
	Socket deadServer: ''.	"Don't reveal any specific server name"
	Symbol rehash.

	Preferences desktopColor: (Color r: 0.2 g: 0.2 b: 0.2).
	ScheduledControllers updateGray; restore.
