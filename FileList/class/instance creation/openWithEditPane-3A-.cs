openWithEditPane: withEdit  "FileList open"
	"Open a view of an instance of me on the default directory.   2/14/96 sw: use standard directory.  (6/96 functionality substantially changed by di)
	 7/12/96 sw: set the label to the pathname"

	| topView aTemplateView fileListView aFileView aFileList aFileTemplateHolder dir volListView |
	topView _ StandardSystemView new.
	aFileList _ self new directory: (dir _ FileDirectory default).
	topView model: aFileList.
	topView label: dir pathName.
	topView minimumSize:
		200 @ (withEdit ifTrue: [200] ifFalse: [60]).

	volListView _ ListView new.
	volListView model: aFileList.
	volListView list: aFileList list.
	volListView window: (0 @ 0 extent: 80 @ 45).
	volListView borderWidthLeft: 2 right: 1 top: 2 bottom: 1.
	topView addSubView: volListView.

	aFileTemplateHolder _ FileTemplateHolder on: aFileList.
	aTemplateView _ StringHolderView new.
	aTemplateView controller: FileTemplateController new.
	aTemplateView model: aFileTemplateHolder.
	aTemplateView window: (0 @ 0 extent: 80 @ 15).
	aTemplateView borderWidthLeft: 2 right: 1 top: 1 bottom: 1.
	topView addSubView: aTemplateView below: volListView.

	fileListView _ FileListView new.
	fileListView model: aFileList.
	fileListView controller: FileListController new.
	fileListView list: aFileList fileList.
	fileListView window: (0 @ 0 extent: 120 @ 60).
	fileListView borderWidthLeft: 1 right: 2 top: 2 bottom: 1.
	topView addSubView: fileListView toRightOf: volListView.

	withEdit ifTrue: [
	aFileView _ FileView new.
	aFileView model: aFileList.
	aFileView window: (0 @ 0 extent: 200 @ 140).
	aFileView borderWidthLeft: 2 right: 2 top: 1 bottom: 2.
	topView addSubView: aFileView below: aTemplateView.
	].

	topView controller open