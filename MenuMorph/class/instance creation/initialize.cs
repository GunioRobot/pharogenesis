initialize

	"MenuMorph initialize"
	
	Preferences
		setParameter: #menuTitleBorderWidth to: 0;
		setParameter: #menuTitleColor to: (TranslucentColor r: 0.87 g: 0.8 b: 1 alpha: 0.65);
		setParameter: #menuColor to: (Color 
			r: (215/255) asFloat 
			g: (220/255) asFloat 
			b: (232/255) asFloat).
	PushPinImage := nil