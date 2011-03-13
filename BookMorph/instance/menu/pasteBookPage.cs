pasteBookPage
	| aPage |
	aPage _ self primaryHand objectToPaste.

	self insertPage: aPage pageSize: aPage extent atIndex: ((pages indexOf: currentPage) - 1).
	"self goToPageMorph: aPage"