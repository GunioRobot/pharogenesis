buildMorphicMessageTextPaneFor: model 
	^ self morphicTextEditorClass new
				on: model
				text: #messageText
				accept: #messageText:
				readSelection: nil
				menu: #messageMenu:shifted:;
		borderWidth: 1;
		yourself