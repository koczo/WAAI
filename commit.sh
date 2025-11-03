#!/bin/bash

# Exit immediately if a command exits with a non-zero status.
set -e

# Check if a commit message was provided.
if [ -z "$1" ]; then
  echo "Error: Commit message is required."
  exit 1
fi

MESSAGE="$1"

# ANSI color codes
CYAN='\033[0;36m'
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m' # No Color

echo -e "${CYAN}Restoring dependencies...${NC}"
#dotnet restore WAAI.sln

echo -e "${CYAN}Formatting code...${NC}"
#dotnet format WAAI.sln --no-restore

echo -e "${CYAN}Building project...${NC}"
#dotnet build --no-restore --nologo

echo -e "${CYAN}Committing changes...${NC}"
git add -A
git commit -m "$MESSAGE"

echo -e "${CYAN}Pushing to remote...${NC}"
git push origin master

echo -e "${GREEN}SUCCESS: Changes committed and pushed!${NC}"
