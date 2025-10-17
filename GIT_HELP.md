# Git Development Guide - Vegia Product Service

## FOR REPOSITORY OWNER (RazaSandhu410)
- Clone: git clone https://github.com/RazaSandhu410/vegia-product-service.git
- Remotes: Only 'origin' needed

## FOR CONTRIBUTORS (Forked Repository)
1. Fork on GitHub
2. Clone: git clone https://github.com/YOUR-USERNAME/vegia-product-service.git  
3. Add upstream: git remote add upstream https://github.com/RazaSandhu410/vegia-product-service.git
4. Sync: git fetch upstream && git merge upstream/dev

## QUICK START
- Setup: git checkout dev && git pull && git checkout -b feature/name
- Daily: git add . && git commit -m \"type: desc\" && git push
- PR: Create at https://github.com/RazaSandhu410/vegia-product-service/pulls

## BRANCH STRATEGY
main - Production
dev - Development  
feature/* - New features
bugfix/* - Bug fixes
hotfix/* - Urgent fixes

## COMMIT TYPES
feat - New feature
fix - Bug fix
docs - Documentation
refactor - Code improvement
test - Tests
chore - Maintenance

## DAILY WORKFLOW - OWNER
1. git checkout dev && git pull origin dev
2. git checkout -b feature/task-name
3. Make changes + git add . + git commit -m \"type: desc\"
4. git push -u origin feature/task-name
5. Create PR on GitHub
6. After merge: git branch -d feature/task-name

## DAILY WORKFLOW - CONTRIBUTOR  
1. git fetch upstream && git checkout -b feature/task-name upstream/dev
2. Make changes + git add . + git commit -m \"type: desc\"
3. git push -u origin feature/task-name
4. Create PR from their fork to original repo
5. After merge: git branch -d feature/task-name

## ESSENTIAL COMMANDS
git status - Check changes
git log --oneline -5 - Recent commits
git branch -a - List branches
dotnet build - Build solution
dotnet test - Run tests

## PROJECT STRUCTURE
Services/ProductService/
├── Vegia.ProductService.API/
├── Vegia.ProductService.Core/
├── Vegia.ProductService.DAL/
├── Vegia.ProductService.BLL/
├── Vegia.ProductService.Reports/
└── Vegia.ProductService.Tests/
