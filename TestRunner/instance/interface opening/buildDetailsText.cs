buildDetailsText
	detailsText _ PluggableTextMorph
				on: self
				text: #details
				accept: nil.
	detailsText hideScrollBarsIndefinitely.
	^detailsText