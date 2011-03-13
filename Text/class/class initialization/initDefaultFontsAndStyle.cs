initDefaultFontsAndStyle
	"This provides the system with 10 and 12 'point' serif and sans-serif font 
	families."

	| defaultFontArray |	
	defaultFontArray _ Array new: 12.
	defaultFontArray at: 1 put: (StrikeFont fromStrike: 'TimesRoman10').
	defaultFontArray at: 2 put:		"(StrikeFont fromStrike: 'TimesRoman10b')."
		((defaultFontArray at: 1) emphasized: 1 named: 'TimesRoman10b').
	defaultFontArray at: 3 put:		"(StrikeFont fromStrike: 'TimesRoman10i')."
		((defaultFontArray at: 1) emphasized: 2 named: 'TimesRoman10i').
	defaultFontArray at: 4 put: (StrikeFont fromStrike: 'TimesRoman12').
	defaultFontArray at: 5 put:		"(StrikeFont fromStrike: 'TimesRoman12b')."
		((defaultFontArray at: 4) emphasized: 1 named: 'TimesRoman12b').
	defaultFontArray at: 6 put:		"(StrikeFont fromStrike: 'TimesRoman12i')."
		((defaultFontArray at: 4) emphasized: 2 named: 'TimesRoman12i').
	defaultFontArray at: 7 put: (StrikeFont fromStrike: 'Helvetica10').
	defaultFontArray at: 8 put:		"(StrikeFont fromStrike: 'Helvetica10b')."
		((defaultFontArray at: 7) emphasized: 1 named: 'Helvetica10b').
	defaultFontArray at: 9 put:		"(StrikeFont fromStrike: 'Helvetica10i')."
		((defaultFontArray at: 7) emphasized: 2 named: 'Helvetica10i').
	defaultFontArray at: 10 put: (StrikeFont fromStrike: 'Helvetica12').
	defaultFontArray at: 11 put:		"(StrikeFont fromStrike: 'Helvetica12b')."
		((defaultFontArray at: 10) emphasized: 1 named: 'Helvetica12b').
	defaultFontArray at: 12 put:		"(StrikeFont fromStrike: 'Helvetica12i')."
		((defaultFontArray at: 10) emphasized: 2 named: 'Helvetica12i').

	TextConstants at: #DefaultTextStyle put:
		(TextStyle fontArray: defaultFontArray).

		"Text initDefaultFontsAndStyle."