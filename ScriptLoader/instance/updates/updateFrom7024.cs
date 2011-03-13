updateFrom7024

	"self new updateFrom7024"
	"
	Compiler:
	 	- Small refactoring of MethodNode>>generate and related methods (needed by 		 
		  MethodWrappers) (Diego Fernandez (and Andrian Lienhard (NetStyle.ch)) )
		- == <integer literal> to = <integer literal> in response to Dan Ingalls' note (fbs)
	OmniBrowser: (Lukas Renggli of NetStyle.ch)
	    - fixes an bug when the browser is opened (Ctrl+B) from non OmniBrowser windows 
		(Debugger, Workspace, ...)
	    - drag and drop methods and categories onto classes
	--------------
	SUnit:
	0003489: ClassTestCase >> selectorsTested misses 'special' methods.

	The method ClassTestCase >> selectorsTested computes the sent messages in a test incorrectly. It 	looks in the literals array, and so misses the 32 'special' message selectors. The correct code 
	is both shorter and simpler. (Andrew Black)
	---------------
	Morphic:
		- 0003416: Faster Moprhic invalidation
		  Morph>>invalidRect:from: was testing for wonderland textures (which where stored in 
		  a property...). (Thanks to Andrew Black for reporting this).
		- Better looking menu title bar (from a mail to the list that I can't find anymore...
		   please use mantis if you want your name to appear here ;-))
	---------------
	Change Set:		ExternalSettingsReorg-tpr
	Date:			5 April 2006
	Author:			tim@rowledge.org

	Reorganise the categories in ExternalSettings to get rid of an explcit '--all--' that can make a 	real mess of filing out the code
	--------------	
	Change Set:		KedamaMissing-KR
	Date:			14 April 2006
	Author:			Korakurider

	add missing method for Kedama
	----------------
	Change Set:		KedamaWODepreciated-KR
	Date:			14 April 2006
	Author:			Korakurider

	refactor kedama not to call depreciated methods.
	note: As showDeprecationWarnings preferece is set to false in Squeakland image, 
	original kedama code run without no problem.
	------------------
	renamed BlockContext>>endpc to be endOC and fix the one sender (md)
	------------------
	Change Set:		MacRomanFix
	Date:			5 April 2006
	Author:			Andreas Raab

	Raise an error if somebody tries to write wide characters.
	----------------------
	0003458: PositionableStream>>copyPreamble:from:at: broken  (Andreas)
	---------
	0003415: Changeset is not updated when renaming a class (Noury)
	After renaming a class, the changeset is not updated to refer to the new name. Therefore, 	
	one virtually lose recorded changes.
	The fix also cleans a bit SystemDictionary. It removes method 	SystemDictionary>>renameClass:from: and uses instead SystemDictionary>>renameClass:as: used 	by traits
	-----------
	0003492: Complete the job of changing the way that arrays are printed (Andrew Black)
	Description
	The new array printing logic introduced in 3.9 had some holes, and needed some cleanup. 	The attached changeset provides it. Tests are included.
	Additional Information
	Specifically, the changeset

	- marks Fractions as selfEveluating and Booleans as literals
	- puts Array>>printOn: back in the printing ctaegory, where someone might expect to find it
	- removes duplicated logic from Collection>>printElementsOn:
	- adds tests for all of the above.
	--------------
	faster asUTC from Avi
	-------------- 
	"
	self script59.
	self flushCaches.
	MCDefinition clearInstances.
	FixInvisible fixFonts