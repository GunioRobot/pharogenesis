buildMorphicStatusPaneFor: model 
	^ PluggableTextMorph new
				on: model
				text: #status
				accept: nil
				readSelection: nil
				menu: nil.