evaluate: actionBlock wheneverChangeIn: aspectBlock
	| viewerThenObject objectThenViewer |
	objectThenViewer _ self.
	viewerThenObject _ ObjectViewer on: objectThenViewer.
	objectThenViewer become: viewerThenObject.
	"--- Then ---"
	objectThenViewer xxxViewedObject: viewerThenObject
			evaluate: actionBlock
			wheneverChangeIn: aspectBlock