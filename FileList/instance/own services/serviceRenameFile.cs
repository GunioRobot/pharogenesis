serviceRenameFile

	^ (SimpleServiceEntry provider: self label: 'rename' selector: #renameFile description: 'rename file')