openOnDatabase: aMailDB
	"Open a MailReader on the given mail database."
	| model views buttons topWindow |
	model _ self new openOnDatabase: aMailDB.
	views _ self buildViewsFor: model.
	buttons _ self buildButtonsFor: model.
	Smalltalk isMorphic
		ifTrue: 
			[topWindow _ (SystemWindow labelled: 'Celeste') model: model.
			topWindow addMorph: (buttons at: 1) frame: (0.0 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 2) frame: (0.125 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 3) frame: (0.25 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 4) frame: (0.375 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 5) frame: (0.5 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 6) frame: (0.625 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 7) frame: (0.75 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (buttons at: 8) frame: (0.875 @ 0.0 extent: 0.125 @ 0.05).
			topWindow addMorph: (views at: 1) frame: (0.0 @ 0.05 extent: 0.2 @ 0.25).
			topWindow addMorph: (views at: 2) frame: (0.2 @ 0.05 extent: 0.8 @ 0.25).
			topWindow addMorph: (views at: 3) frame: (0.0 @ 0.3 extent: 1.0 @ 0.65).
			topWindow addMorph: (views at: 4) frame: (0.0 @ 0.95 extent: 1.0 @ 0.05).
			buttons do: [:b | b onColor: Color lightGray offColor: Color white].
			topWindow openInWorld]
		ifFalse: 
			[topWindow _ StandardSystemView new model: model;
					 label: 'Celeste';
					 minimumSize: 400 @ 250.
			(views at: 1) window: (0 @ 0 extent: 20 @ 25).
			(views at: 2) window: (0 @ 0 extent: 80 @ 25).
			(views at: 3) window: (0 @ 0 extent: 100 @ 70).
			(buttons at: 1) window: (0 @ 0 extent: 12 @ 5).
			(buttons at: 2) window: (0 @ 0 extent: 12 @ 5).
			(buttons at: 3) window: (0 @ 0 extent: 12 @ 5).
			(buttons at: 4) window: (0 @ 0 extent: 10 @ 5).
			(buttons at: 5) window: (0 @ 0 extent: 13 @ 5).
			(buttons at: 6) window: (0 @ 0 extent: 13 @ 5).
			(buttons at: 7) window: (0 @ 0 extent: 15 @ 5).
			(buttons at: 8) window: (0 @ 0 extent: 13 @ 5).
			topWindow addSubView: (buttons at: 1);
			 addSubView: (buttons at: 2) toRightOf: (buttons at: 1);
			 addSubView: (buttons at: 3) toRightOf: (buttons at: 2);
			 addSubView: (buttons at: 4) toRightOf: (buttons at: 3);
			 addSubView: (buttons at: 5) toRightOf: (buttons at: 4);
			 addSubView: (buttons at: 6) toRightOf: (buttons at: 5);
			 addSubView: (buttons at: 7) toRightOf: (buttons at: 6);
			 addSubView: (buttons at: 8) toRightOf: (buttons at: 7);
			 addSubView: (views at: 1) below: (buttons at: 1);
			 addSubView: (views at: 2) toRightOf: (views at: 1);
			 addSubView: (views at: 3) below: (views at: 1).
			topWindow controller open]