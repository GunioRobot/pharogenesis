initialize	"SystemMonitor initialize"

	MonitorDelay _ 1000.								"milliseconds between updates"

	Inset _ 2.										"inset from monitor border (outside) to bars and labels"
	BorderWidth _ 1.									"width of border around entire monitor"
	BorderColor _ Color black.						"colour of border around entire monitor"
	BackgroundColor _ Color gray.		"background colour for monitor area"
	ForegroundColor _ Color black.					"foreground colour for bar labels"

	DefaultBarHeight _ 8.							"height of bar for undecorated display (no labels)"
	BarWidth _ 200.									"horizontal (long-axis) size of each bar"
	BarBorderWidth _ 1.								"width of border around each bar"
	BarBorderColor _ Color black.					"colour of border around each bar"
	BarBackgroundColor _ Color veryLightGray.		"background colour (inactive region) of bar"
	BarColors _ Array
		with: Color darkGray						"colour of first bar segment"
		with: Color lightRed						"colour of second bar segment"
		with: Color lightBlue							"colour of third bar segment"
		with: Color lightGreen.						"colour of fourth bar segment"