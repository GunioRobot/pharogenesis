editThisThread

	| sz morphsForPageSorter sorter pixelsAvailable pixelsNeeded scale |

	"a bit of fudging to try to outguess the layout mechanism and get best possible scale"
	pixelsAvailable _ Display extent - 130.
	pixelsAvailable _ pixelsAvailable x * pixelsAvailable y.
	pixelsNeeded _ 100@75.
	pixelsNeeded _ pixelsNeeded x * pixelsNeeded y  * listOfPages size.
	scale _ (pixelsAvailable / pixelsNeeded min: 1) sqrt.
	sz _ (100@75 * scale) rounded.

	morphsForPageSorter _ self morphsForMyContentsSizedTo: sz.
	morphsForPageSorter _ morphsForPageSorter reject: [ :each | each isNil].
	sorter _ BookPageSorterMorph new.
	sorter changeExtent: Display extent.

	sorter
		book: self 
		morphsToSort: morphsForPageSorter.
	sorter pageHolder cursor: self currentIndex.
	self currentWorld addMorphFront: sorter.
	sorter align: sorter center with: self currentWorld center.

