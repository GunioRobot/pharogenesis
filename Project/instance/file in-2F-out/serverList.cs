serverList
	"Take my list of server URLs and return a list of ServerDirectories to write on.  Each starts with ftp://"

	urlList ifNil: [^ urlList _ Array new: 0].
	^ urlList collect: [:url | 
		ServerDirectory new fullPath: url]