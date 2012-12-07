ntee
====

Like Unix tee, ntee is yet another Windows command line tee utility that echos standard input back to standard output and then redirects it to one or more files.

Examples
--------

To echo and redirect the output of the `dir` command to a new file:

	dir | ntee log.txt

By default, ntee will overwrite existing files. To append instead:

	dir | ntee /a log.txt

And for multiple files:

	dir | ntee /a log1.txt log2.txt

Enjoy!