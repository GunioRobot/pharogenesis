thumbnailFromUrl: urlString
	| preStream |
	"Load the project, and make a thumbnail to it in the current project.
Project thumbnailFromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/SqueakEasy.extSeg'.
"

	preStream _ (ServerFile new fullPath: urlString) asStream.
	ProjectViewMorph openFromFile: preStream