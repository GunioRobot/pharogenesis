buildButtonsFor: model 
	"Answer a collection of handy buttons for the Celeste user interface."
	| buttonViewClass buttons b sw |
	Smalltalk isMorphic
		ifTrue: [buttonViewClass _ PluggableButtonMorph]
		ifFalse: [buttonViewClass _ PluggableButtonView].
	buttons _ OrderedCollection new.

	sw _ Switch new.
	b _ buttonViewClass on: (sw onAction: [model subjectFilterOn: sw];
				 offAction: [model subjectFilterOff]).
	b label: 'Subj. F.';
		borderWidth: 1.
	b setBalloonText: 'Show messages with specific Subject: line content'.
	buttons add: b.

	sw _ Switch new.
	b _ buttonViewClass on: (sw onAction: [model fromFilterOn: sw];
				 offAction: [model fromFilterOff]).
	b label: 'From F.';
		borderWidth: 1.
	b setBalloonText: 'Show messages with specific From: line content'.
	buttons add: b.

	b _ buttonViewClass
				on: model
				getState: #isCustomFilterOn
				action: #customFilterOn.
	b label: 'Custom F.';
		borderWidth: 1.


	
	b setBalloonText: 'Show messages which match a generalized custom filter'.
	buttons add: b.

b _ buttonViewClass
				on: model
				getState: nil
				action: #customFilterMove.
	b label: 'Custom F. Move';
	 borderWidth: 1.
	b setBalloonText: 'Move messages which match a custom filter to appropriate category'.
	buttons add: b.

	b _ buttonViewClass new model: (Button new onAction: [model compose]);
			 action: #turnOn;
			 label: 'New';
			 borderWidth: 1.
	b setBalloonText: 'Compose a new message'.
	buttons add: b.

	b _ buttonViewClass new model: (Button new onAction: [model reply]);
			 action: #turnOn;
			 label: 'Reply';
			 borderWidth: 1.
	b setBalloonText: 'Reply to the selected message'.
	buttons add: b.

	b _ buttonViewClass new model: (Button new onAction: [model forward]);
			 action: #turnOn;
			 label: 'Forward';
			 borderWidth: 1.
	b setBalloonText: 'Forward the selected message'.
	buttons add: b.

	b _ buttonViewClass new model: (Button new onAction: [model moveAgain]);
			 action: #turnOn;
			 label: 'Move Again';
			 borderWidth: 1.
	b setBalloonText: 'Move the selected message to the same category as previously'.
	buttons add: b.

	b _ buttonViewClass new model: (Button new onAction: [model deleteMessage]);
			 action: #turnOn;
			 label: 'Delete';
			 borderWidth: 1.
	b setBalloonText: 'Delete the selected message'.
	buttons add: b.

	^ buttons