# Uniprot Annotation Downloader

## Contents

- [Overview](#overview)
- [Repo Contents](#repo-contents)
- [System Requirements](#system-requirements)
- [Installation Guide](#installation-guide)
- [Demo](#demo)
- [Results](#results)
- [License](./LICENSE)
- [Issues](https://github.com/ebridge2/lol/issues)
- [Citation](#citation)


# Overview

A standalone software tool that retrieves subcellular location, topology annotation, signal peptides, regions and amino acid modifications from UniProt database. The output is a compressed (.gz) ready-to-use file for the [Perseus software platform](https://maxquant.net/perseus/)

## Installation

You can simply download and run the <b>UniProt Annotation Downloader.exe</b> executable file which is located under the <b>bin/Release</b> directory of this GitHub repository. Additionally, a sample file with a list of UniProt IDs is provided under the <b>test_files</b> directory for testing purposes. Press the button 'Select File', choose a file which contains a list of UniProt IDs, select or deselect the annotation categories of your interest (by default all options are selected and will be downloaded) and click 'Start'. The tool retrieves in real-time all the selected features for the given protein IDs from [UniProt](https://www.uniprot.org/). 

![alt text](https://github.com/gkoulouras/uniprot-annotation-downloader/blob/master/UniProtAnnotDownloader.png)

Next, locate the <b>proteinAnnotations.txt.gz</b> file which will be created by the software and simply copy and paste it (you can optionally rename it as well) into the <b>bin/conf/annotations</b> folder of the Perseus software. Re-start Perseus (in case it's already open) and you will be able to see the new annotation in Perseus GUI by selecting Annot. columns --> Add Annotation , as shown below.

![alt text](https://github.com/gkoulouras/uniprot-annotation-downloader/blob/master/PerseusScreenShot1.png)

# System Requirements

The latest release of the software (version 1.0.4) has been tested on Windows 10 operating systems.


<b>Contact:</b>

For questions, suggestions, bug-reports or feedback, please get in touch by email:
<ul><li>gkoulouras {at} gmail {dot} com</li></ul>

<b>Citation:</b>

If you use this tool or data derived from this software in your research work please consider citing the following DOI: [10.5281/zenodo.6645639](https://doi.org/10.5281/zenodo.6645639)

![alt text](https://github.com/gkoulouras/uniprot-annotation-downloader/blob/master/zenodo.6645639.svg)

<b>License:</b>

This project is licensed under the Apache 2.0 license, quoted below.

Copyright (c) 2019 Grigorios Koulouras

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at [http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

