buildMorphicMessageTextPaneFor: model 
	^ PluggableTextMorph new
				on: model
				text: #messageText
				accept: #messageText:
				readSelection: nil
				menu: #messageMenu:shifted: