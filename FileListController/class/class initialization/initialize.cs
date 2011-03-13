initialize
	"Initialize the file list menu.  6/96 di; modified 7/12/96 sw to add the file-into-new-change-set feature"

	FileListYellowButtonMenu _ PopUpMenu labels:
'fileIn
file into new change set
import GIF into GIFImports
import GIF into HyperSqueak
load HyperSqueak stack
browse changes
spawn this file
sort by name
sort by size
sort by date
copy name
rename
delete
add new file' lines: # (3 5 7 10 ).
	FileListYellowButtonMessages _ #(fileInSelection fileIntoNewChangeSet importGIF imporHyperSqueaktGIF loadIntoHyperSqueak browseChanges editFile sortByName sortBySize sortByDate copyName renameFile deleteFile addNewFile)

	"FileListController initialize"