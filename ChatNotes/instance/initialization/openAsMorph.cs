openAsMorph
	| window aColor recordButton stopButton playButton saveButton |

	window _ (SystemWindow labelled: 'Audio Notes') model: self.

	window addMorph: (
		(PluggableListMorph 
			on: self 
			list: #notesList 
			selected: #notesListIndex 
			changeSelected: #notesListIndex: 
			menu: #notesMenu:
		) autoDeselect: false) frame: (0@0 corner: 0.5@1.0).

	nameTextMorph _ PluggableTextMorph on: self text: #name accept: nil.
	nameTextMorph askBeforeDiscardingEdits: false.
	window addMorph: nameTextMorph frame: (0.5@0 corner: 1.0@0.4).

	aColor _ Color colorFrom: self defaultBackgroundColor.

	(recordButton _ PluggableButtonMorph on: self getState: #isRecording action: #record)
		label: 'record';
		askBeforeChanging: true;
		color: aColor;
		onColor: aColor darker offColor: aColor.
	window addMorph: recordButton frame: (0.5@0.4 corner: 0.75@0.7).

	(stopButton _ PluggableButtonMorph on: self getState: #isStopped action: #stop)
		label: 'stop';
		askBeforeChanging: true;
		color: aColor;
		onColor: aColor darker offColor: aColor.
	window addMorph: stopButton frame: (0.75@0.4 corner: 1.0@0.7).

	(playButton _ PluggableButtonMorph on: self getState: #isPlaying action: #play)
		label: 'play';
		askBeforeChanging: true;
		color: aColor;
		onColor: aColor darker offColor: aColor.
	window addMorph: playButton frame: (0.5@0.7 corner: 0.75@1.0).

	(saveButton _ PluggableButtonMorph on: self getState: #isSaving action: #save)
		label: 'save';
		askBeforeChanging: true;
		color: aColor;
		onColor: aColor darker offColor: aColor.
	window addMorph: saveButton frame: (0.75@0.7 corner: 1.0@1.0).

	window openInWorld.