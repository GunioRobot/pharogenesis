compileUsingClosures	"Utilities compileUsingClosures"
	"Recompile the system and do some minimal clean-ups"
	| classes compilationErrors |
	Preferences setPreference: #allowBlockArgumentAssignment toValue: true.
	compilationErrors := Set new.
	classes := Smalltalk forgetDoIts allClasses reject: [:c| c name == #GeniePlugin].

	'Recompiling The System' displayProgressAt: Sensor cursorPoint
		from: 0 to: classes size during:[:bar |
			classes withIndexDo:[:c :i|
				bar value: i.
				{ c. c class } do:[:b|
					"Transcript cr; print: b; endEntry."
					b selectors "asSortedCollection" do:[:s| 
						"Transcript cr; show: b asString, '>>', s."
						[b recompile: s from: b] on: Error do:[:ex|
							Transcript
								cr; nextPutAll: 'COMPILATION ERROR: ';
								print: b; nextPutAll: '>>'; nextPutAll: s; flush.
							compilationErrors add: (MethodReference class: b selector: s)]]]]].

	(Smalltalk respondsTo: #allTraits) ifTrue:[
		'Recompiling Traits' displayProgressAt: Sensor cursorPoint
		from: 0 to: Smalltalk allTraits size during:[:bar |
			Smalltalk allTraits do:[:t|
				t selectors do:[:s|
					[t recompile: s] on: Error do:[:ex|
							Transcript
								cr; nextPutAll: 'COMPILATION ERROR: ';
								print: t; nextPutAll: '>>'; nextPutAll: s; flush.
							compilationErrors add: (MethodReference class: t selector: s)]]]]].

	compilationErrors notEmpty ifTrue:[
		SystemNavigation default
			browseMessageList: compilationErrors asSortedCollection
			name: 'Compilation Errors'].