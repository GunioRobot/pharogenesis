initializeFontMap
	"Initialize the dictionary mapping font names to substitutions for Postscript code generation."
	"PostscriptCanvas initializeFontMap"
	| f |
	FontMap := Dictionary new.
	FontMap
		at: 'NewYork' put: (f _ self fontsForNewYork);
		at: 'Accuny' put: f;

		at: 'Helvetica' put: (f _ self fontsForHelvetica);
		at: 'Accujen' put: f;
				
		at: 'Palatino' put: self fontsForPalatino;
		
		at: 'ComicBold' put: (f _ self fontsForComicBold);
		at: 'Accuat' put: self fontsForAccuAt;
		
		at: 'ComicPlain' put: self fontsForComicPlain