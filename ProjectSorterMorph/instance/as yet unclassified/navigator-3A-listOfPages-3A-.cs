navigator: aThreadNavigator listOfPages: listOfPages

	| morphsForPageSorter pixelsAvailable pixelsNeeded scale |

	"a bit of fudging to try to outguess the layout mechanism and get best possible scale"
	pixelsAvailable _ Display extent - 130.
	pixelsAvailable _ pixelsAvailable x * pixelsAvailable y.
	pixelsNeeded _ 100@75.
	pixelsNeeded _ pixelsNeeded x * pixelsNeeded y  * listOfPages size.
	scale _ (pixelsAvailable / pixelsNeeded min: 1) sqrt.
	sizeOfEachMorph _ (100@75 * scale) rounded.

	morphsForPageSorter _ self morphsForMyContentsFrom: listOfPages sizedTo: sizeOfEachMorph.
	morphsForPageSorter _ morphsForPageSorter reject: [ :each | each isNil].
	self changeExtent: Display extent.

	self
		book: aThreadNavigator 
		morphsToSort: morphsForPageSorter.
	pageHolder 
		cursor: aThreadNavigator currentIndex;
		fullBounds;
		hResizing: #rigid.

