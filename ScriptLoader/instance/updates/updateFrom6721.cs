updateFrom6721
	"self new updateFrom6721"
	"
	- remove Deprecated Methods from 3.8
	- moved all new deprecated method to *39Deprecated
	- remove MethodNode>>#generateNative
	- add generate (to call generate: #(0 0 0 0), fix senders to use it
	- add CompiledMethod>>#equivalentTo:
	- fix for 0002513: arcTan: returns angle in strange intervale
	- fix for 0002118: Integer class >> #primesUpTo: 
	- fix for 0001109: ScrollPane code/comment mismatch
	- start of a ReleaseTest (testing for Undeclareds etc...)
	- Change Set:		versionCats-bf
	  Author:			Bert Freudenberg
       Show method categories in version listing. Particularily useful when checking 
       overrides, where the only thing changed is the categorization.
	- BorderedMoph.st from Connectors
	- fixes from 0001734: [ENH] remove deprecated Chronology methods in 3.9 [cd][su][sm]
	- Change Set:		systemSupportFixes-bf
	  Author:			Bert Freudenberg
	  Fixes to SmalltalkImage
	  - rename readDocumentFile to recordStartupStamp, which is what it does nowadays
	  - changesName is full path now, like imageName
	  - derive full name for new image or changes from image path primitive, rather 
	    than default directory (in all regular cases they are identical)
	- 0002570: [Fix] When Color prety printing it is hard to read the light tan literals against 
	 the white background.
	- Change Set:		AnnotationMorphFix-wiz
	 Author:			(wiz) Jerome Peace
	 Made some style changes to the annotation preference widget.  Two things. put the 
	 extra button in a better place. Made a more harmonious aspect ratio for the panels.

	
	"
	Smalltalk removeEmptyMessageCategories.
	ColoredCodeStream initialize.
	
	self script33.
	self flushCaches.
	