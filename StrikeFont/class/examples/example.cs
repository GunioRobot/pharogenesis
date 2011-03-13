example
	"Displays a line of text on the display screen at the location of the cursor.
	Example depends on the strike font file, 'TimesRoman10.strike'. existing."

	| font |
	font _ StrikeFont fromStrike: 'TimesRoman10'.
	font displayLine: 'A line of text in times roman style' at: Sensor cursorPoint
	 
	"StrikeFont example."