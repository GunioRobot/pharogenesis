showHelpWindow
	((StringHolder new contents: 'The Crostic Panel presents an acrostic puzzle for solution.  As you type in answers for the clues, the letters also get entered in the text of the hidden quote.  Conversely, as you guess words in the quote, those letters will fill in missing places in your answers.  In addition, the first letters of all the answers together form the author''s name and title of the work from which the quote is taken.

If you wish to make up other acrostic puzzles, follow the obvious file format in the sampleFile method.  If you wish to print an acrostic to work it on paper, then change the oldStyle method to return true, and it will properly cross-index all the cells.

Have fun.' translated)
		embeddedInMorphicWindowLabeled: 'About the Crostic Panel' translated)
		setWindowColor: (Color
				r: 1.0
				g: 0.6
				b: 0.0);
		 openInWorld: self world extent: 409 @ 207