windowColorSpecification
	"Answer a WindowColorSpec object that declares my preference"

	^ WindowColorSpec classSymbol: self name wording: 'Package Browser' brightColor: #(1.0 1.0 0.6)	 pastelColor: #(0.976 0.976 0.835) helpMessage: 'A system browser with an extra pane at top-left for module.'